<template>
  <el-card shadow="never">
    <div style="text-align: center">
      <img src="/logo-geosnipa.png" alt="logo" width="180" />
    </div>
    <el-divider />
    <div>
      <h1
        style="
          font-size: 0.8rem;
          font-weight: bolder;
          margin: 0;
          margin-bottom: 0.5rem;
        "
      >
        Usuario:
        <u style="text-transform: uppercase">{{ $auth.user?.username }}</u>
      </h1>
      <el-button
        type="danger"
        size="mini"
        icon="el-icon-switch-button"
        @click="cerrarSesion()"
      >
        Cerrar sesión
      </el-button>
    </div>
  </el-card>
</template>

<script>
export default {
  methods: {
    cerrarSesion() {
      this.$auth.logout();
    },
  },
};
</script>
