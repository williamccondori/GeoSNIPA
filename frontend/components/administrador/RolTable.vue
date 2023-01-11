<template>
  <el-table stripe :data="usuarios" border>
    <el-table-column prop="username" label="Nombre de usuario" />
    <el-table-column prop="roles" label="Roles">
      <template slot-scope="scope">
        <div style="display: flex; gap: 0.5rem">
          <el-tag
            v-for="rol in scope.row.roles"
            :key="rol"
            :type="obtenerColor(rol)"
          >
            {{ rol }}
          </el-tag>
        </div>
      </template>
    </el-table-column>
    <el-table-column label="Acciones">
      <template slot-scope="scope">
        <el-button
          v-if="!scope.row.roles.includes('superusuario')"
          type="text"
          icon="el-icon-edit"
          @click="editar(scope.row.id)"
        />
      </template>
    </el-table-column>
  </el-table>
</template>

<script>
import { mapState, mapActions } from "vuex";
export default {
  async fetch() {
    try {
      await this.obtenerTodosUsuarios();
    } catch (error) {
      this.$message.error(error);
    }
  },
  computed: {
    ...mapState("administrador", ["usuarios"]),
  },
  methods: {
    ...mapActions("administrador", [
      "obtenerTodosUsuarios",
      "abrirRolDrawerParaActualizacion",
    ]),
    obtenerColor(rol) {
      switch (rol) {
        case "superusuario":
          return "success";
        case "administrador":
          return "warning";
        default:
          return "primary";
      }
    },
    async editar(capaBaseId) {
      try {
        const { data } = await this.$axios.get(`/usuarios/${capaBaseId}`);
        this.abrirRolDrawerParaActualizacion(data);
      } catch (error) {
        this.$message.error(error);
      }
    },
  },
};
</script>
