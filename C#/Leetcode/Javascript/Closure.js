//definition:A closure is the combination of a function and the lexical environment within 
//              which that function was declared.

//ref : https://developer.mozilla.org/en-US/docs/Web/JavaScript/Closures

makeFunc = () => {
    var name = 'local';
    displayName = () => {  // this is a closure
        alert(name);
    };

    return displayName;
}

// myFunc holds display name function along with the local variable name.
var myFunc = makeFunc(); 
myFunc();