function sizeSelect(sizeName) {
    var sizeClass = document.getElementsByClassName(sizeName + '-active');
    // if already active do nothing
    if (sizeClass.length > 0) {
        return false;
        // if not active
    } else {        
        if (sizeName == "small") {
            // add class to button      
            $('#' + sizeName).addClass(sizeName + '-active');
            //set other buttons to non active after clicked
            $('#medium').removeClass('medium-active');
            $('#large').removeClass('large-active');
        } else if (sizeName == "medium") {
            $('#' + sizeName).addClass(sizeName + '-active');
            $('#small').removeClass('small-active');
            $('#large').removeClass('large-active');
        } else if (sizeName == "large") {
            $('#' + sizeName).addClass(sizeName + '-active');
            $('#small').removeClass('small-active');
            $('#medium').removeClass('medium-active');
        }
    }
};

