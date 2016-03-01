var jsonRequester = (function () {

    function send(method, url, options, contentType) {
        options = options || {};
        contentType = contentType || 'application/json';

        var headers = options.headers || {},
            data = options.data || {},
            dataType = options.dataType || 'json',
            promise = {};

        promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                method: method,
                contentType: contentType,
                headers: headers,
                data: data,
                dataType: dataType,
                success: function (res) {
                    resolve(res);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function get(url, options, contentType) {
        return send('GET', url, options, contentType);
    }

    function post(url, options, contentType) {
        return send('POST', url, options, contentType);
    }

    function put(url, options, contentType) {
        return send('PUT', url, options);
    }

    function del(url, options, contentType) {
        return send('POST', url, options);
    }

    return {
        send: send,
        get: get,
        post: post,
        put: put,
        delete: del
    };
}());