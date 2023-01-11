<template>
  <AdministradorPage>
    <el-alert
      type="success"
      title="¡Bienvenido al módulo de administración del GEOSNIPA!"
      description="Módulo de administración de contenidos de la plataforma geoespacial GEOSNIPA"
      style="margin-bottom: 1rem"
      :closable="false"
    />
    <div
      v-if="resumen"
      style="
        display: grid;
        gap: 1rem;
        grid-template-columns: repeat(auto-fit, minmax(15rem, 1fr));
      "
    >
      <el-card shadow="hover">
        <el-statistic
          :value="resumen.totalSubproyectos"
          title="Total de sub proyectos"
        />
      </el-card>
      <el-card shadow="hover">
        <el-statistic
          :value="resumen.totalCapasBase"
          title="Total de capas base"
        />
      </el-card>
      <el-card shadow="hover">
        <el-statistic
          :value="resumen.totalServiciosExternos"
          title="Total de servicios externos"
        />
      </el-card>
      <el-card shadow="hover">
        <el-statistic
          :value="resumen.totalUsuarios"
          title="Total de usuarios"
        />
      </el-card>
    </div>
  </AdministradorPage>
</template>

<script>
import { mapState, mapActions } from "vuex";
export default {
  layout: "administrador",
  async fetch() {
    try {
      await this.obtenerResumen();
    } catch (error) {
      this.$message.error(error);
    }
  },
  computed: {
    ...mapState("administrador", ["resumen"]),
  },
  methods: {
    ...mapActions("administrador", ["obtenerResumen"]),
  },
};
</script>
