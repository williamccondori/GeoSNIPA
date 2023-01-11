<template>
  <AdministradorPage titulo="Servicios externos">
    <el-button
      type="primary"
      icon="el-icon-plus"
      style="margin-bottom: 1rem"
      @click="abrirServicioExternoDrawer"
    >
      Agregar servicio externo
    </el-button>
    <ServicioExternoTable />
    <ServicioExternoDrawer />
  </AdministradorPage>
</template>

<script>
import { mapActions } from "vuex";
import AdministradorPage from "@/components/administrador/compartido/AdministradorPage.vue";
import ServicioExternoDrawer from "~/components/administrador/ServicioExternoDrawer.vue";
import ServicioExternoTable from "@/components/administrador/ServicioExternoTable.vue";
export default {
  components: {
    AdministradorPage,
    ServicioExternoTable,
    ServicioExternoDrawer,
  },
  layout: "administrador",
  methods: {
    ...mapActions("administrador", ["abrirServicioExternoDrawer"]),
  },
};
</script>
