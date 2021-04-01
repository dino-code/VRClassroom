from flask import Flask, request
from psycopg2 import connect

application = Flask(__name__)

@application.route('/')
def main():
    return 'Welcome'

# This route is taken when an entry is to be added
@application.route('/addEntry', methods=['POST', 'GET'])
def add_entry():
    if request.method == 'POST':
        # get a dict of the form passed from VRClassroom app: {'firstName': '', 'lastName': '', 'email': '', 'password': '', 'status': ''}
        data = request.form.to_dict()
        
        # connect to aws database instance
        conn = connect(host='database-2.cxulhfpnprky.us-east-1.rds.amazonaws.com', port='5432', user='postgres', password='Finance123!', dbname='myDatabase')
        cur = conn.cursor()

        cmd =  '''INSERT INTO Users VALUES(%s, %s, %s, %s, %s)'''

        cur.execute(cmd, (data['firstName'], data['lastName'], data['email'], data['password'], data['status'],))

        conn.commit()

        cur.close()
        conn.close()

    return 'Complete'

'''
@application.route('/checkEntry', methods=['POST', 'GET'])
def add_entry():
    if request.method == 'POST':
'''

if __name__ == "__main__":
    # Setting debug to True enables debug output. This line should be
    # removed before deploying a production app.
    application.debug = True
    application.run()