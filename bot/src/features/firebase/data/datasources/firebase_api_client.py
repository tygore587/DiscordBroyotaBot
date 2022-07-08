from abc import abstractmethod

from src.core.data.api_client import ApiClient
from src.features.firebase.data.models.tokenResult import TokenResult


class FirebaseApiClient(ApiClient):
    @abstractmethod
    async def get_token(self) -> TokenResult:
        pass

    @abstractmethod
    async def refresh_token(self, refresh_token: str) -> TokenResult:
        pass
