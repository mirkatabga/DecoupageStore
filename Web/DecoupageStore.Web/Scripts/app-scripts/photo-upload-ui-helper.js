var fileUploadHelper = (function () {
    function getFilesNamesAsOneString(files, separator) {
        var filesNamesAsString = "",
            defaultSeparator = ";";

        if (!files) {
            return;
        }

        if (!separator) {
            separator = defaultSeparator;
        }

        if (typeof(separator) != "string") {
            separator = defaultSeparator;
        }

        for (var i = 0; i < files.length; i++) {
            if (files[i]) {
                if (i === files.length - 1) {
                    filesNamesAsString += files[i].name;
                }
                else {
                    filesNamesAsString += files[i].name + separator;
                }
            }
        }

        return filesNamesAsString;
    }

    return {
        getFilesNamesAsOneString: getFilesNamesAsOneString
    }
}());