from abc import abstractmethod

from src.core.data.api_client import ApiClient
from src.features.doppler.data.models.dopplerSecrets import DopplerSecrets


class DopplerApiClient(ApiClient):
    @abstractmethod
    async def get_secrets(self, base64_secret: str) -> DopplerSecrets:
        pass
