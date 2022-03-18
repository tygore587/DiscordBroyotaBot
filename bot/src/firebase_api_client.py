from dataclasses import dataclass

import requests


@dataclass
class FirebaseLoginResult:
    display_name: str
    id_token: str
    refresh_token: str
    expires_in: int


@dataclass
class FirebaseLoginCredentials:
    email: str
    password: str


class FirebaseApiClient:

    def __init__(self, api_key: str):
        self.api_key = api_key

    def login_user(self, credentials: FirebaseLoginCredentials) -> FirebaseLoginResult:
        query = {"key": self.api_key}
        body = {"email": credentials.email, "password": credentials.password, "returnSecureToken": True}

        response = requests.post('https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword', data=body,
                                 params=query)

        response.raise_for_status()

        response_data = response.json()
        display_name = response_data["displayName"]
        id_token = response_data["idToken"]
        refresh_token = response_data["refreshToken"]
        expires_in = response_data['expiresIn']

        return FirebaseLoginResult(display_name=display_name, id_token=id_token, refresh_token=refresh_token,
                                   expires_in=expires_in)
