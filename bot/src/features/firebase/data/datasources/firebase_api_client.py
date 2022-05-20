from dataclasses import dataclass
from datetime import datetime, timedelta
from functools import lru_cache

import requests


@dataclass
class FirebaseLoginCredentials:
    email: str
    password: str


@dataclass
class TokenResult:
    id_token: str
    refresh_token: str
    expires_at: datetime


@dataclass(frozen=True, eq=True)
class CacheKey:
    email: str
    password: str


class FirebaseApiClient:

    def __init__(self, api_key: str):
        self.api_key = api_key
        self.cache: dict[CacheKey, TokenResult] = dict()

    def get_token(self, credentials: FirebaseLoginCredentials) -> str:
        cache_key = self._get_cache_key(credentials)

        current_token = self.cache.get(cache_key)
        if not current_token:
            new_token = self._login_user(credentials)
            self.cache[cache_key] = new_token
            return new_token.id_token

        if not current_token.expires_at > datetime.utcnow():
            return current_token.id_token

        new_token = self._refresh_token(current_token.refresh_token)

        self.cache[cache_key] = new_token

        return new_token.id_token

    @staticmethod
    def _get_cache_key(credentials: FirebaseLoginCredentials) -> CacheKey:
        return CacheKey(credentials.email, credentials.password)

    def _refresh_token(self, refresh_token) -> TokenResult:
        query = {"key": self.api_key}
        body = {
            "grant_type": "refresh_token",
            "refresh_token": refresh_token
        }

        response = requests.post('https://securetoken.googleapis.com/v1/token', data=body, params=query)

        response.raise_for_status()

        response_data = response.json()

        id_token = response_data["id_token"]
        refresh_token = response_data["refresh_token"]
        expires_in = int(response_data["expires_in"])

        expires_at = datetime.utcnow() + timedelta(seconds=expires_in)

        return TokenResult(id_token=id_token, refresh_token=refresh_token, expires_at=expires_at)

    def _login_user(self, credentials: FirebaseLoginCredentials) -> TokenResult:
        print("Got new token from api")
        query = {"key": self.api_key}
        body = {"email": credentials.email,
                "password": credentials.password, "returnSecureToken": True}

        response = requests.post('https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword', data=body,
                                 params=query)

        response.raise_for_status()

        response_data = response.json()
        id_token = response_data["idToken"]
        refresh_token = response_data["refreshToken"]
        expires_in = int(response_data['expiresIn'])

        expires_at = datetime.utcnow() + timedelta(seconds=expires_in)

        return TokenResult(id_token=id_token, refresh_token=refresh_token, expires_at=expires_at)
