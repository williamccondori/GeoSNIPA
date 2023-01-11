export const state = () => ({
  resumen: undefined,
  capaBase: undefined,
  capasBase: [],
  servicioExterno: undefined,
  serviciosExternos: [],
  gruposCapas: [],
  usuario: undefined,
  usuarios: [],
  configuraciones: [],
  estaAbiertoCapaBaseDrawer: false,
  estaAbiertoServicioExternoDrawer: false,
  estaAbiertoGrupoCapaDrawer: false,
  estaAbiertoUsuarioDrawer: false,
  estaAbiertoRolDrawer: false,
});

export const actions = {
  async obtenerResumen({ commit }) {
    const { data } = await this.$axios.get("/resumenes/");
    commit("establecerResumen", data);
  },
  async obtenerTodosCapasBase({ commit }) {
    const { data } = await this.$axios.get("/capas-base/");
    commit("establecerCapasBase", data);
  },
  abrirCapaBaseDrawer({ commit }) {
    commit("establecerCapaBase", undefined);
    commit("establecerCapaBaseDrawerAbierto", true);
  },
  abrirCapaBaseDrawerParaActualizacion({ commit }, capaBase) {
    commit("establecerCapaBase", capaBase);
    commit("establecerCapaBaseDrawerAbierto", true);
  },
  cerrarCapaBaseDrawer({ commit }) {
    commit("establecerCapaBaseDrawerAbierto", false);
  },
  abrirServicioExternoDrawer({ commit }) {
    commit("establecerServicioExterno", undefined);
    commit("establecerServicioExternoDrawerAbierto", true);
  },
  abrirServicioExternoDrawerParaModificacion({ commit }, servicioExterno) {
    commit("establecerServicioExterno", servicioExterno);
    commit("establecerServicioExternoDrawerAbierto", true);
  },
  cerrarServicioExternoDrawer: ({ commit }) =>
    commit("establecerServicioExternoDrawerAbierto", false),
  async obtenerTodosGruposCapas({ commit }) {
    const { data } = await this.$axios.get("/grupos-capas/");
    commit("establecerGruposCapas", data);
  },
  abrirGrupoCapaDrawer: ({ commit }) =>
    commit("establecerGrupoCapaDrawerAbierto", true),
  cerrarGrupoCapaDrawer({ commit }) {
    commit("establecerGrupoCapaDrawerAbierto", false);
  },
  async obtenerTodosUsuarios({ commit }) {
    const { data } = await this.$axios.get("/usuarios/");
    commit("establecerUsuarios", data);
  },
  abrirUsuarioDrawer({ commit }) {
    commit("establecerUsuario", undefined);
    commit("establecerUsuarioDrawerAbierto", true);
  },
  abrirUsuarioDrawerParaActualizacion({ commit }, usuario) {
    commit("establecerUsuario", usuario);
    commit("establecerUsuarioDrawerAbierto", true);
  },
  cerrarUsuarioDrawer({ commit }) {
    commit("establecerUsuarioDrawerAbierto", false);
  },
  abrirRolDrawerParaActualizacion({ commit }, usuario) {
    commit("establecerUsuario", usuario);
    commit("establecerRolDrawerAbierto", true);
  },
  cerrarRolDrawer({ commit }) {
    commit("establecerRolDrawerAbierto", false);
  },
  async obtenerTodosConfiguraciones({ commit }) {
    const { data } = await this.$axios.get("/configuraciones/");
    commit("establecerConfiguraciones", data);
  },
};

export const mutations = {
  establecerCapaBaseDrawerAbierto: (state, payload) =>
    (state.estaAbiertoCapaBaseDrawer = payload),
  establecerServicioExternoDrawerAbierto: (state, payload) =>
    (state.estaAbiertoServicioExternoDrawer = payload),
  establecerGrupoCapaDrawerAbierto: (state, payload) =>
    (state.estaAbiertoGrupoCapaDrawer = payload),
  establecerUsuarioDrawerAbierto: (state, payload) =>
    (state.estaAbiertoUsuarioDrawer = payload),
  establecerRolDrawerAbierto: (state, payload) =>
    (state.estaAbiertoRolDrawer = payload),
  establecerResumen: (state, payload) => (state.resumen = payload),
  establecerCapaBase: (state, payload) => (state.capaBase = payload),
  establecerCapasBase: (state, payload) => (state.capasBase = payload),
  establecerGruposCapas: (state, payload) => (state.gruposCapas = payload),
  establecerUsuario: (state, payload) => (state.usuario = payload),
  establecerUsuarios: (state, payload) => (state.usuarios = payload),
  establecerConfiguraciones: (state, payload) =>
    (state.configuraciones = payload),
};
