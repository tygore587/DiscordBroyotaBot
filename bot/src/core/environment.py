from abc import ABC
from dataclasses import dataclass
import os
from dotenv import load_dotenv


@dataclass
class EnvironmentVariables(ABC):
    @staticmethod
    def get_doppler_service_token() -> str:
        return EnvironmentVariables.__get_variable_from_os("DOPPLER_SERVICE_TOKEN_BASE64")

    @staticmethod
    def __get_variable_from_os(name: str) -> str:
        return os.environ[name]


class EnvironmentHelper(ABC):

    @staticmethod
    def load_environment():
        load_dotenv()
