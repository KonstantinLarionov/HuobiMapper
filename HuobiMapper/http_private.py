from cgi import print_arguments
from os import write
import requests
from urllib import parse
import json
from datetime import datetime
import hmac
import sys
import base64
from hashlib import sha256

def _get_url_suffix(method: str, access_key: str, secret_key: str, host: str, path: str) -> str:
    # it's utc time and an example is 2017-05-11T15:19:30
    timestamp = datetime.utcnow().strftime('%Y-%m-%dT%H:%M:%S')
    timestamp = parse.quote(timestamp)  # url encode
    suffix = 'AccessKeyId={}&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp={}'.format(
        access_key, timestamp)
    payload = '{}\n{}\n{}\n{}'.format(method.upper(), host, path, suffix)

    digest = hmac.new(secret_key.encode('utf8'), payload.encode(
        'utf8'), digestmod=sha256).digest()  # make sha256 with binary data

    # base64 encode with binary data and then get string
    signature = base64.b64encode(digest).decode()
    signature = parse.quote(signature)  # url encode

    suffix = '{}&Signature={}'.format(suffix, signature)
    return suffix


def post(access_key: str, secret_key: str, host: str, path: str, data: dict = None) -> json:
    url = 'https://{}{}?{}'.format(host, path, _get_url_suffix(
        'post', access_key, secret_key, host, path))
    headers = {'Accept': 'application/json',
                'Content-type': 'application/json'}
    # json means data with json format string in http body
    res = requests.post(url, json=data, headers=headers)
    data = res.json()
    return data
  


if __name__ == '__main__':

    access_key = sys.argv[1]
    secret_key = sys.argv[2]

    # usdt-swap
    host = sys.argv[3]
    path = sys.argv[4]
    params = None
    print(sys.argv[5])

    if(sys.argv[5] != "{}"):
        params = json.loads(sys.argv[5].replace("'","\""))

    print(params)
    print('{}'.format(post(access_key, secret_key, host, path, params)))
    exit;
