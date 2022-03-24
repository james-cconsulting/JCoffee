function opSelect(name) {
    var buttonClass = document.getElementsByClassName(name + '-active');
    if (buttonClass.length > 0) {
        $('#' + name).removeClass(name + '-active');
    } else {
        $('#' + name).addClass(name + '-active');
    }
};