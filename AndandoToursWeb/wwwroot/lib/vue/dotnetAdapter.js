const RenderEngine = require('./renderEngine');
module.exports = (callback, data) => {
    callback(null, RenderEngine().Render(data));
}