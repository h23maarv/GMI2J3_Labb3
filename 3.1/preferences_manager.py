from interfaces import IDBClient, IFileReader
from typing import Dict

class PreferencesManager:
    def __init__(self, db_client: IDBClient, file_reader: IFileReader):
        """
        Initialize the PreferencesManager with external dependencies.

        Args:
            db_client (IDBClient): An object responsible for checking if a user exists.
            file_reader (IFileReader): An object responsible for retrieving user preferences.
        """
        self.db_client = db_client
        self.file_reader = file_reader

    def get_user_preferences(self, username: str) -> Dict[str, str]:
        """
        Get the preferences for a specific user.

        This method first verifies that the user exists in the database,
        and then attempts to retrieve their preferences from the file system.

        Args:
            username (str): The username whose preferences should be retrieved.

        Returns:
            Dict[str, str]: A dictionary of user preferences.

        Raises:
            ValueError: If the user does not exist in the database.
        """
        if not self.db_client.user_exists(username):
            raise ValueError(f"User '{username}' not found")
        return self.file_reader.read_preferences(username)