const Plugins = [
  // jQuery
  {
    from: 'node_modules/jquery/dist',
    to  : '~/Content/plugins/jquery'
  },
  // Popper
  {
    from: 'node_modules/popper.js/dist',
    to  : '~/Content/plugins/popper'
  },
  // Bootstrap
  {
    from: 'node_modules/bootstrap/dist',
    to  : '~/Content/plugins/bootstrap'
  },
  // Font Awesome
  {
    from: 'node_modules/font-awesome/css',
    to  : '~/Content/plugins/font-awesome/css'
  },
  {
    from: 'node_modules/font-awesome/fonts',
    to  : '~/Content/plugins/font-awesome/fonts'
  },
  // Chart.js 2
  {
    from: 'node_modules/chart.js/dist/',
    to  : '~/Content/plugins/chart.js'
  },
  // CKEditor
  {
    from: 'node_modules/@ckeditor/ckeditor5-build-classic/build/',
    to  : '~/Content/plugins/ckeditor'
  },
  // DataTables
  {
    from: 'node_modules/datatables.net/js',
    to: '~/Content/plugins/datatables'
  },
  {
    from: 'node_modules/datatables.net-bs4/js',
    to: '~/Content/plugins/datatables'
  },
  {
    from: 'node_modules/datatables.net-bs4/css',
    to: '~/Content/plugins/datatables'
  }
]

module.exports = Plugins
