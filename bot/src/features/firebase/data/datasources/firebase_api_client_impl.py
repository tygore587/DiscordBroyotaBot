from datetime import datetime, timedelta

from httpx import AsyncClient

from src.features.firebase.data.datasources.firebase_api_client import FirebaseApiClient
from src.features.firebase.data.models.firebaseLoginCredentials import FirebaseLoginCredentials
from src.features.firebase.data.models.tokenResult import TokenResult


class FirebaseApiClientImpl(FirebaseApiClient):

    def __init__(self, client: AsyncClient, api_key: str, credentials: FirebaseLoginCredentials):
        super().__init__(client)
        self.api_key = api_key
        self.credentials = credentials

    async def get_token(self) -> TokenResult:
        return await self._login_user(credentials=self.credentials)

    async def refresh_token(self, refresh_token: str) -> TokenResult:
        query = {"key": self.api_key}
        body = {
            "grant_type": "refresh_token",
            "refresh_token": refresh_token
        }

        response = await self.client.post('https://securetoken.googleapis.com/v1/token', data=body, params=query)

        response.raise_for_status()

        response_data = response.json()

        id_token = response_data["id_token"]
        refresh_token = response_data["refresh_token"]
        expires_in = int(response_data["expires_in"])

        expires_at = datetime.utcnow() + timedelta(seconds=expires_in)

        return TokenResult(id_token=id_token, refresh_token=refresh_token, expires_at=expires_at)

    async def _login_user(self, credentials: FirebaseLoginCredentials) -> TokenResult:
        print("Got new token from api")
        query = {"key": self.api_key}
        body = {"email": credentials.email,
                "password": credentials.password, "returnSecureToken": True}

        response = await self.client.post('https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword',
                                          data=body,
                                          params=query)

        response.raise_for_status()

        response_data = response.json()
        id_token = response_data["idToken"]
        refresh_token = response_data["refreshToken"]
        expires_in = int(response_data['expiresIn'])

        expires_at = datetime.utcnow() + timedelta(seconds=expires_in)

        return TokenResult(id_token=id_token, refresh_token=refresh_token, expires_at=expires_at)
