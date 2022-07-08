from httpx import AsyncClient

from src.features.broyota_api.data.datasources.broyota_api_client import BroyotaApiClient


class BroyotaApiClientImpl(BroyotaApiClient):
    def __init__(self, client: AsyncClient):
        super().__init__(client)

    async def get_example(self) -> None:
        await self.client.get(url="https://example.com")
