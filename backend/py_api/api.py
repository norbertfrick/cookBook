from flask import Flask

import flask.scaffold
flask.helpers._endpoint_from_view_func = flask.scaffold._endpoint_from_view_func

from flask_restful import Resource, Api

app = Flask(__name__)
api = Api(app)


# https://www.youtube.com/watch?v=GMppyAPbLYk

class Api(Resource):
    def get(self):
        return {'hello' : 'world'}

    def getByName(self, name):
        return {'hello' : f'{name}'}


    def post(self):
        return {"data": "posted"}
    

api.add_resource(Api, "/hello")
api.add_resource(Api, "/hello/<string:name>")

if __name__ == "__main__":
    app.run(debug=True)