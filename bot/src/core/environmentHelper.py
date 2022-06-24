from abc import ABC

from dotenv import load_dotenv


class EnvironmentHelper(ABC):

    @staticmethod
    def load_environment():
        load_dotenv()
