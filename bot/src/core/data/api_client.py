import asyncio
from abc import ABC

from httpx import AsyncClient


class ApiClient(ABC):

    def __init__(self, client: AsyncClient):
        self.client = client

    def __del__(self):
        try:
            loop = asyncio.get_event_loop()
            if loop.is_running():
                loop.create_task(self.client.aclose())
            else:
                loop.run_until_complete(self.client.aclose())
        finally:
            pass
