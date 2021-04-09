from flask import Flask, request
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
        data = request.get_json()
        
        # connect to aws database instance
        conn = connect(host='database-2.cxulhfpnprky.us-east-1.rds.amazonaws.com', port='5432', user='postgres', password='Finance123!', dbname='myDatabase')
        cur = conn.cursor()

        cmd =  '''INSERT INTO Users VALUES(%s, %s, %s, %s, %s)'''

        cur.execute(cmd, (data['firstName'], data['lastName'], data['email'], data['password'], data['status'],))

        conn.commit()

        cur.close()
        conn.close()

    return 'Complete'

@application.route('/checkForExistingEmail', methods=['POST'])
def checkForExistingEmail():
    data = request.get_json()
        
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
        return 'email exists'
    else:
        # email does not exist
        return 'email does not exist'

@application.route('/validateLoginCredentials', methods=['POST'])
def validateLoginCredentials():
    data = request.get_json()
        
    # connect to aws database instance
    conn = connect(host='database-2.cxulhfpnprky.us-east-1.rds.amazonaws.com', port='5432', user='postgres', password='Finance123!', dbname='myDatabase')
    cur = conn.cursor()

    cmd = '''SELECT * FROM Users WHERE email=%s and password=%s'''
    cur.execute(cmd, (data['email'], data['password'],))

    rows = cur.fetchall()

    cur.close()
    conn.close()

    if len(rows) > 0:
        # the email exists in the db
        return 'account exists'
    else:
        # email does not exist
        return 'account does not exist'
