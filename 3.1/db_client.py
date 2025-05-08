from interfaces import IDBClient

class DBClient(IDBClient):
    def __init__(self):
        # Simulated in-memory user database using a Python set.
        # In a real application, this would be replaced by a database query.
        self._users = {"alice", "bob", "carol"}

    def user_exists(self, username: str) -> bool:
        """
        Check whether the specified user exists in the database.

        Args:
            username (str): The username to look up.

        Returns:
            bool: True if the user exists, False otherwise.
        """
        return username in self._users