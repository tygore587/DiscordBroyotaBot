# This is a sample Python script.

# Press ⌃R to execute it or replace it with your code.
# Press Double ⇧ to search everywhere for classes, files, tool windows, actions, and settings.
import asyncio
import os
import time

import aiohttp


async def print_hi(name):
    # Use a breakpoint in the code line below to debug your script.
    print(f'Hi, {name}')  # Press ⌘F8 to toggle the breakpoint.
    api_url = os.environ.get("API_URL")
    full_url = f'http://{api_url}'
    print(f'Full URL is: {full_url}')

    async with aiohttp.ClientSession() as session:
        while True:
            async with session.get(full_url) as response:
                print(await response.text())
                print('wait 5 seconds.')
                await asyncio.sleep(5)


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    loop = asyncio.get_event_loop()
    loop.run_until_complete(print_hi("Hi PyCharm"))

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
