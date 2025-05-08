from abc import ABC, abstractmethod
from typing import Dict

class IDBClient(ABC):
    @abstractmethod
    def user_exists(self, username: str) -> bool:
        """
        Check whether a user exists in the data source.

        Args:
            username (str): The username to check.

        Returns:
            bool: True if the user exists, False otherwise.
        """
        pass

class IFileReader(ABC):
    @abstractmethod
    def read_preferences(self, username: str) -> Dict[str, str]:
        """
        Retrieve stored preferences for the given user.

        Args:
            username (str): The username whose preferences should be retrieved.

        Returns:
            Dict[str, str]: A dictionary containing user preferences.
        """
        pass