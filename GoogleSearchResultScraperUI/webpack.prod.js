const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const InlineChunkHtmlPlugin = require("react-dev-utils/InlineChunkHtmlPlugin");
const {merge} = require("webpack-merge");
const common = require("./webpack.common.js");

module.exports = merge(common, {
  mode: "production",
  plugins: [
    new HtmlWebpackPlugin({
      inject: "body",
      template: path.join(__dirname, "public/index.html"),
    }),
    new InlineChunkHtmlPlugin(HtmlWebpackPlugin, [/.js$/]),
  ],
});
