import requests
from bs4 import BeautifulSoup
from pymongo.mongo_client import MongoClient
from pymongo.server_api import ServerApi
import json
uri = "mongodb://localhost:27017/"
client = MongoClient(uri)
db = client['bd-party-tree']
collection = db['party-overview']
# Making a GET request
r = requests.get('https://www.ecs.gov.bd/page/political-parties?lang=en')
print(r)
# Parsing the HTML
soup = BeautifulSoup(r.content, 'html.parser')
table = soup.find('table')
if table:
    # Iterate over each row in the table
    rows = table.find_all('tr')
    id=1
    for row in rows:
        # Find all cells in the row
        cells = row.find_all('td')
        data = {}
        if(cells):
            data['id']=id
            id+=1
        # Iterate over each cell
        for index, cell in enumerate(cells):
            # Find all <p> elements within the cell
            data['pid']=1
            p = cell.find('p')
            if p:
                if p.find('img'):
                    data['icon'] = p.find('img').get('src')
                elif p.find('a'):
                    name = p.find('a').get_text()
                    data['name'] = name
                    if len(name.split('-'))>1:
                        data['title']= name.split('-')[1]
                else:
                    if index==1:
                        name=p.get_text()
                        data['name'] = name
                        if len(name.split('-'))>1:
                            data['title']= name.split('-')[1]
                        
                    elif index==2:
                        data['established']=p.get_text()
                    elif index==3:
                        data['icon_name']=p.get_text() 
        if data:
            print(f'Data: {data}')
            collection.insert_one(data)
                             
else:
    print("No table found on the page.")
