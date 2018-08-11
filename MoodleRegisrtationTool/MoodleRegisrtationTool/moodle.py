# -*- encoding: utf-8 -*-
##############################################################################
#
#    Moodle Webservice
#    Copyright (c) 2011 Zikzakmedia S.L. (http://zikzakmedia.com) All Rights Reserved.
#                       Raimon Esteve <resteve@zikzakmedia.com>
#                       Jesus Martín <jmartin@zikzakmedia.com>
#    $Id$
#
#    This program is free software: you can redistribute it and/or modify
#    it under the terms of the GNU Affero General Public License as
#    published by the Free Software Foundation, either version 3 of the
#    License, or (at your option) any later version.
#
#    This program is distributed in the hope that it will be useful,
#    but WITHOUT ANY WARRANTY; without even the implied warranty of
#    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
#    GNU Affero General Public License for more details.
#
#    You should have received a copy of the GNU Affero General Public License
#    along with this program.  If not, see <http://www.gnu.org/licenses/>.
#
##############################################################################


def rest_protocol(server, params, function=None, key_word=None):
    """
    Construct the correct function to call
    """
    if function is None:
        function = ""
    if key_word is None:
        key_word = ""
    count = 0
    if(params is list or params is dict): # RON YUTKIN
        for param in params:
            if type(param) is dict:
                for item in iter(param):
                    function += '&%s[%s][%s]=' % (key_word, str(count), item)
                    function += '%s' % param[item]
            else:
                function += '&%s[%s]=' % (key_word, str(count))
                function += '%s' % param
            count += 1
    else:                                               # RON YUTKIN
        function+='&{0}={1}'.format(key_word, params)   # RON YUTKIN
    
    return conn_rest(server, function)
    
def conn_rest(server, function):
    """
    Connection to Moodle with REST Webservice
    server = {
        'protocol': 'rest',
        'uri': 'http://www.mymoodle.org',
        'token': 'mytokenkey',
    }
    """
    if 'uri' not in server or 'token' not in server:
        return False

    if server['uri'][-1] == '/':
        server['uri'] = server['uri'][:-1]

    url = '%s/webservice/%s/server.php' % (server['uri'], server['protocol'])
    data = 'wstoken=%s&wsfunction=%s' % (server['token'], function)

    return '{0}?{1}'.format(url, data)
    
def conn_xmlrpc(server, service=None, params=None):
    """
    Connection to Moodle with XML-RPC Webservice
    server = {
        'protocol': 'xmlrpc',
        'uri': 'http://www.mymoodle.org',
        'token': 'mytokenkey',
    }
    """
    if 'uri' not in server or 'token' not in server:
        return False

    import xmlrpclib

    if server['uri'][-1] == '/':
        server['uri'] = server['uri'][:-1]

    url = '%s/webservice/%s/server.php?wstoken=%s' % (server['uri'], server['protocol'], server['token'])
    return xmlrpclib.ServerProxy(url)
    
def xmlrpc_protocol(server, params, function=None, key_word=None):
    """
    Select the correct function to call
    """

    def moodle_course_get_courses(params):
        return proxy.moodle_course_get_courses()
    
    def moodle_course_create_courses(params):
        return proxy.moodle_course_create_courses(params)
        
    def moodle_user_get_users_by_id(params):
        return proxy.moodle_user_get_users_by_id(params)

    def moodle_user_create_users(params):
        return proxy.moodle_user_create_users(params)
        
    def moodle_user_update_users(params):
        return proxy.moodle_user_update_users(params)
        
    def moodle_enrol_manual_enrol_users(params):
        return proxy.moodle_enrol_manual_enrol_users(params)
        
    def not_implemented_yet(params):
        return False

    proxy = self.conn_xmlrpc(server)
    select_method = {
        "moodle_course_get_courses": moodle_course_get_courses,
        "moodle_course_create_courses": moodle_course_create_courses,
        "moodle_user_get_users_by_id": moodle_user_get_users_by_id,
        "moodle_user_create_users": moodle_user_create_users,
        "moodle_user_update_users": moodle_user_update_users,
        "moodle_enrol_manual_enrol_users": moodle_enrol_manual_enrol_users,
        "not_implemented_yet": not_implemented_yet,
    }

    if function is None or function not in select_method:
        function = "not_implemented_yet"
    return select_method[function](params)