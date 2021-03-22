from flask import Flask, request
from psycopg2 import connect

app = Flask(__name__)

# This route is taken when an entry is to be added
@app.route('/addEntry', methods=['POST', 'GET'])
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