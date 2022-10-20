
var signatureBytes = CryptoJS.HmacSHA256('123', '123');
var signature = CryptoJS.enc.Base64.stringify(signatureBytes);

log(signature);