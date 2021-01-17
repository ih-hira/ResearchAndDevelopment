from pymongo import MongoClient

client = MongoClient("mongodb+srv://ihhira:462618@cluster0.0wzwd.mongodb.net/mflix?retryWrites=true&w=majority")
db = client.mflix
collection = db.movie_list
print(db)
print(collection)

pipeline1 = [
    {
        '$group': {
            '_id': {"language": "$language"},
            'count': {'$sum': 1}
        }
    }
]

pipeline2 = [
    # First stage
    {
        '$group': {
            '_id': "$language",
            'count': {'$sum': 1}
        }
    },
    # Second stage
    {
        '$sort': {'count': -1}
    }
]

filter1 = {
    '$match': {'language': 'Korean,English'}
}

# print(list(collection.aggregate(pipeline1)))
print(list(collection.find(filter1)))


