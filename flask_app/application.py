from flask import Flask, request, jsonify
from psycopg2 import connect

application = Flask(__name__)

@application.route('/')
def main():
    return 'Welcome'

# This route is taken when an entry is to be added
@application.route('/addNewUser', methods=['POST'])
def addNewUser():
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

@application.route('/checkForExistingEmail', methods=['GET'])
def checkForExistingEmail():
    data = request.form.to_dict()
        
    # connect to aws database instance
    conn = connect(host='database-2.cxulhfpnprky.us-east-1.rds.amazonaws.com', port='5432', user='postgres', password='Finance123!', dbname='myDatabase')
    cur = conn.cursor()

    cmd = '''SELECT * FROM Users WHERE email=%s'''
    cur.execute(cmd, (data['email'],))

    rows = cur.fetchall()

    cur.close()
    conn.close()

    if len(rows) > 0:
        # the email exists in the db
        return jsonify(result=True, id=id)
    else:
        # email does not exist
        return jsonify(result=False, id=id)
