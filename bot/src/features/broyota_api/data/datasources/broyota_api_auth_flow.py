import asyncio
from datetime import datetime
from typing import AsyncGenerator

from httpx import Request, Response, Auth

from src.features.firebase.data.datasources.firebase_api_client import FirebaseApiClient
from src.features.firebase.data.models.tokenResult import TokenResult


class BroyotaApiAuthFlow(Auth):
    requires_response_body = True

    def __init__(self, firebase_api_client: FirebaseApiClient):
        self.access_token = ""
        self.refresh_token = ""
        self.token_expires_at_utc = datetime.min
        self.firebase_api_client = firebase_api_client

        # add async lock so only one process refreshes the token
        self._async_lock = asyncio.Lock()

    async def async_auth_flow(
            self, request: Request
    ) -> AsyncGenerator[Request, Response]:
        token = await self._get_token()

        request.headers["Authorization"] = f"Bearer {token}"
        yield request

    async def _get_token(self) -> str:
        async with self._async_lock:
            if self.access_token and self.token_expires_at_utc > datetime.utcnow():
                return self.access_token

            token_result = await self._refresh_token() if self.refresh_token else await self._get_token_from_api()

            self.access_token = token_result.id_token
            self.refresh_token = token_result.refresh_token
            self.token_expires_at_utc = token_result.expires_at

            return token_result.id_token

    async def _refresh_token(self) -> TokenResult:
        return await self.firebase_api_client.refresh_token(self.refresh_token)

    async def _get_token_from_api(self) -> TokenResult:
        return await self.firebase_api_client.get_token()
