export default {
  ssr: false,
  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: "demo-element",
    htmlAttrs: {
      lang: "es",
    },
    meta: [
      { charset: "utf-8" },
      { name: "viewport", content: "width=device-width, initial-scale=1" },
      { hid: "description", name: "description", content: "" },
      { name: "format-detection", content: "telephone=no" },
    ],
    link: [{ rel: "icon", type: "image/x-icon", href: "/favicon.ico" }],
  },

  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: ["@/plugins/element-ui"],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [],

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: ["@nuxtjs/axios", "@nuxtjs/auth-next"],

  // Axios module configuration: https://go.nuxtjs.dev/config-axios
  axios: {
    // Workaround to avoid enforcing hard-coded localhost:3000: https://github.com/nuxt-community/axios-module/issues/308
    baseURL: process.env.BASE_URL || "http://localhost:8000/api/v1",
  },

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {
    transpile: [/^element-ui/],
  },

  // Router Configuration: https://nuxtjs.org/docs/2.x/configuration-glossary/configuration-router
  router: {
    middleware: ["auth"],
  },

  // Auth Configuration: https://auth.nuxtjs.org/guide/setup
  auth: {
    redirect: {
      login: "/login",
      home: "/administrador",
    },
    strategies: {
      local: {
        token: {
          property: "access_token",
        },
        user: { property: false },
        endpoints: {
          login: { url: "/auth/", method: "post" },
          user: { url: "/auth/user/", method: "get" },
          logout: false,
        },
      },
    },
  },
};
