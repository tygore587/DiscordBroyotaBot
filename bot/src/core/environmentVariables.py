import os
from abc import ABC
from dataclasses import dataclass


@dataclass
class EnvironmentVariables(ABC):
    @staticmethod
    def get_doppler_service_token() -> str:
        return EnvironmentVariables.__get_variable_from_os("DOPPLER_SERVICE_TOKEN_BASE64")

    @staticmethod
    def __get_variable_from_os(name: str) -> str:
        return os.environ[name]
