from flask_restful import Resource

class Recipes(Resource):
    def get(self):
        return { 'recipe' : 'recipe'}

    

