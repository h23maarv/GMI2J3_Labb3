# Using Python.org or Miniconda
# pip/conda install selenium webdriver-manager
#
import time
import unittest
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.common.exceptions import NoAlertPresentException
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.service import Service

def check_alert(num, text):
    if num in {11, 13, 17, 19}:
        assert "true" in text.lower(), f"{num} should be prime!"
    else:
        assert "false" in text.lower(), f"{num} should not be prime!"

class PrimeGUITest(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()))
        self.driver.get("file:///YOUR/PATH/TO/prime-assert1")  # Replace with your local path
        time.sleep(1)

    def tearDown(self):
        self.driver.quit()

    def test_prime_check(self):
        driver = self.driver
        input_field = driver.find_element(By.ID, "primeinput")
        button = driver.find_element(By.ID, "inpbtn")

        for number in range(10, 20):
            input_field.clear()
            input_field.send_keys(str(number))
            button.click()

            time.sleep(0.5)  # Vänta på alert
            try:
                alert = driver.switch_to.alert
                alert_text = alert.text
                print(f"Alert text for {number}: {alert_text}")
                check_alert(number, alert_text)
                alert.accept()
            except NoAlertPresentException:
                print(f"No alert for {number}")

if __name__ == "__main__":
    unittest.main()