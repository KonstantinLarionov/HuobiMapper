#-*- coding: UTF-8 -*-
from urllib import parse
from datetime import datetime
import hmac
import base64
from hashlib import sha256
from sys import argv

script, first, second = argv
access_key = first
secret_key = second

host = 'api.hbdm.com'
path = '/linear-swap-api/v1/swap_account_info'
timestamp = datetime.utcnow().strftime('%Y-%m-%dT%H:%M:%S')
timestamp = parse.quote(timestamp)

method = 'post'

suffix = 'AccessKeyId={}&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp={}'.format(access_key, timestamp)
payload = '{}\n{}\n{}\n{}'.format(method.upper(), host, path, suffix)

digest = hmac.new(secret_key.encode('utf8'), payload.encode('utf8'), digestmod=sha256).digest()

signature = base64.b64encode(digest).decode()
signature = parse.quote(signature)

suffix = '{}&Signature={}'.format(suffix, signature)
print(suffix)
exit()