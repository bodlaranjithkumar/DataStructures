//Javascript promises - https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise

var myAsyncFunc = (url) => {
    return new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();
        xhr.open("GET", url);
        xhr.onload = () => resolve(xhr.responseText);
        xhr.onerror = () => reject(xhr.statusText);
        xhr.send();
    });
}

myAsyncFunc
    .then((responseText) => { console.log(resonseText); })
    .catch((errorText) => { console.log(errorText); })