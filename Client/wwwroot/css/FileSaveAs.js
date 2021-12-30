function FileSaveAs(data, name) {
    var arrBuffer = _base64ToArrayBuffer(data);

    // It is necessary to create a new blob object with mime-type explicitly set
    // otherwise only Chrome works like it should
    var newBlob = new Blob([arrBuffer]);

    // IE doesn't allow using a blob object directly as link href
    // instead it is necessary to use msSaveOrOpenBlob
    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
        window.navigator.msSaveOrOpenBlob(newBlob);
        return;
    }

    // For other browsers: 
    // Create a link pointing to the ObjectURL containing the blob.
    var data = window.URL.createObjectURL(newBlob);

    var link = document.createElement('a');
    document.body.appendChild(link); //required in FF, optional for Chrome
    link.href = data;
    link.download = name;
    link.click();
    window.URL.revokeObjectURL(data);
    link.remove();
}
function _base64ToArrayBuffer(base64) {
    var binary_string = window.atob(base64);
    var len = binary_string.length;
    var bytes = new Uint8Array(len);
    for (var i = 0; i < len; i++) {
        bytes[i] = binary_string.charCodeAt(i);
    }
    return bytes.buffer;
}
