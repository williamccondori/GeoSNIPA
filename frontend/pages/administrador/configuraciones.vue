<template>
  <AdministradorPage titulo="Configuraciones">
    <el-tabs type="card">
      <el-tab-pane label="Usuarios">
        <el-button
          type="primary"
          icon="el-icon-plus"
          style="margin-bottom: 1rem"
          @click="abrirUsuarioDrawer"
        >
          Crear usuario
        </el-button>
        <UsuarioTable />
        <UsuarioDrawer />
      </el-tab-pane>
      <el-tab-pane label="Roles">
        <RolTable />
        <RolDrawer />
      </el-tab-pane>
      <el-tab-pane label="Variables">
        <VariableForm />
      </el-tab-pane>
    </el-tabs>
  </AdministradorPage>
</template>

<script>
import { mapActions } from "vuex";
import AdministradorPage from "@/components/administrador/compartido/AdministradorPage.vue";
import UsuarioDrawer from "~/components/administrador/UsuarioDrawer.vue";
import UsuarioTable from "@/components/administrador/UsuarioTable.vue";
import RolTable from "@/components/administrador/RolTable.vue";
import RolDrawer from "@/components/administrador/RolDrawer.vue";
import VariableForm from "~/components/administrador/VariableForm.vue";
export default {
  components: {
    AdministradorPage,
    UsuarioTable,
    UsuarioDrawer,
    RolTable,
    RolDrawer,
    VariableForm,
  },
  layout: "administrador",
  methods: {
    ...mapActions("administrador", ["abrirUsuarioDrawer"]),
  },
};
</script>
