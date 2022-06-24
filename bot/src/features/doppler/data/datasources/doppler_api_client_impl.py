from httpx import AsyncClient

from src.features.doppler.data.datasources.doppler_api_client import DopplerApiClient
from src.features.doppler.data.models.dopplerSecrets import DopplerSecrets


class DopplerApiClientImpl(DopplerApiClient):

    def __init__(self, client: AsyncClient):
        super().__init__(client)

    async def get_secrets(self, base64_secret: str) -> DopplerSecrets:
        headers = {
            "Authorization": f'Basic {base64_secret}'}

        response = await self.client.get(
            'https://api.doppler.com/v3/configs/config/secrets/download?format=json', headers=headers)

        response.raise_for_status()

        content = response.json()

        fb_api_key = str(content['FIREBASE_API_KEY'])
        fb_login_mail = str(content['FIREBASE_LOGIN_MAIL'])
        fb_login_password = str(content['FIREBASE_LOGIN_PASSWORD'])

        return DopplerSecrets(firebase_api_key=fb_api_key, firebase_login_mail=fb_login_mail,
                              firebase_login_password=fb_login_password)
