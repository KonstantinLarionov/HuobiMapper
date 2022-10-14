var accessKey = "__APIKEY__";
var secretKey = "__SECRET__";

var signatureVersion = __SIGNVERSION__;
var signatureMethod = "__SIGNMETHOD__";
var timestamp = new Date().toISOString().slice(0, 19);

// Get request detail form postman
var requestMethod = "__METHOD__";
var queryParam = "__QUERYPARAMS__";
var host = "__HOST__";
var path = "__PATH__";

var queryList = {
    values: [],
    sigkey: ["AccessKeyId", "SignatureVersion", "SignatureMethod", "Timestamp", "Signature"],
    put: function(k, v){
        var index = -1;
        for(var i = 0;i<this.values.length;i++){
            var key = this.values[i].split("=")[0];

            if(key==k){
                index = -1;
                break;
            }
        }
        var value = encodeURIComponent(v);
        if(index==-1){
            this.values.push(k+"="+value);
        }else{
            this.values[index] = k+"="+value;
        }
    },
    sortedValues: function(){
        return this.values.sort();
    },
    inSigkey: function(k){
        for(var i = 0; i<this.sigkey.length; i++){
            if(k == this.sigkey[i]){
                return true;
            }
        }
        return false
    }
};

for(var i = 0;i<queryParam.length;i++){
    if(queryParam[i].disabled||queryList.inSigkey(queryParam[i].key))
        continue;
    queryList.put(queryParam[i].key, queryParam[i].value);
}
queryList.put("Timestamp",timestamp);
queryList.put("AccessKeyId",accessKey);
queryList.put("SignatureMethod",signatureMethod);
queryList.put("SignatureVersion",signatureVersion);

var payload = requestMethod.toUpperCase()+"\n"+
    host.toLowerCase()+"\n"+
    path+"\n"+
    queryList.sortedValues().join("&");

console.log(payload);

var signatureBytes = CryptoJS.HmacSHA256(payload, secretKey);
var signature = CryptoJS.enc.Base64.stringify(signatureBytes);
return signature;