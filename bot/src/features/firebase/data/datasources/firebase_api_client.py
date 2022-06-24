from abc import abstractmethod

from src.core.data.api_client import ApiClient


class FirebaseApiClient(ApiClient):
    @abstractmethod
    async def get_token(self) -> str:
        pass
