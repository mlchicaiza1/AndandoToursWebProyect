const fs = require('fs');
const path = require('path');
const bundle = require('./dist/server.bundle.js');
const renderer = require('vue-server-renderer').createRenderer({
    template: require('fs').readFileSync('./index.html', 'utf-8')
});
module.exports = function RenderEngine() {
    function Render(context) {
        var result = '';
        renderer.renderToString(bundle.default(), context, (err, html) => {
            console.log(err);
            result = html;
        });
        return result;
    }
    return {
        Render
    }
}