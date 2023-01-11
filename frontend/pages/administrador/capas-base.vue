<template>
  <AdministradorPage titulo="Capas base">
    <el-button
      type="primary"
      icon="el-icon-plus"
      style="margin-bottom: 1rem"
      @click="abrirCapaBaseDrawer"
    >
      Crear capa base
    </el-button>
    <CapaBaseTable />
    <CapaBaseDrawer />
  </AdministradorPage>
</template>

<script>
import { mapActions } from "vuex";
import AdministradorPage from "@/components/administrador/compartido/AdministradorPage.vue";
import CapaBaseDrawer from "~/components/administrador/CapaBaseDrawer.vue";
import CapaBaseTable from "@/components/administrador/CapaBaseTable.vue";
export default {
  components: {
    AdministradorPage,
    CapaBaseTable,
    CapaBaseDrawer,
  },
  layout: "administrador",
  methods: {
    ...mapActions("administrador", ["abrirCapaBaseDrawer"]),
  },
};
</script>
