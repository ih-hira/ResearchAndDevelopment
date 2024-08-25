from flask import Flask, jsonify
from pymongo import MongoClient
from flask_cors import CORS

app = Flask(__name__)
CORS(app)
uri = "mongodb://localhost:27017/"
client = MongoClient(uri)
db = client['bd-party-tree']
collection = db['party-overview']


@app.route('/api/getPartyOverview', methods=['GET'])
def get_data():
    data = list(collection.find({}, {"_id": 0}))
    return jsonify(data)

if __name__ == '__main__':
    app.run(debug=True)