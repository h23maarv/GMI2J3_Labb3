from abc import ABC, abstractmethod
from typing import Dict

class IDBClient(ABC):
    @abstractmethod
    def user_exists(self, username: str) -> bool:
        pass

class IFileReader(ABC):
    @abstractmethod
    def read_preferences(self, username: str) -> Dict[str, str]:
        pass