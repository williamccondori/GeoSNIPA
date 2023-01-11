<template>
  <el-table stripe :data="usuarios" border>
    <el-table-column prop="username" label="Nombre de usuario" />
    <el-table-column label="Acciones">
      <template slot-scope="scope">
        <el-button
          type="text"
          icon="el-icon-edit"
          @click="editar(scope.row.id)"
        />
        <el-button
          type="text"
          icon="el-icon-delete"
          @click="eliminar(scope.row.id)"
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
      "abrirUsuarioDrawerParaActualizacion",
    ]),
    async editar(capaBaseId) {
      try {
        const { data } = await this.$axios.get(`/usuarios/${capaBaseId}`);
        this.abrirUsuarioDrawerParaActualizacion(data);
      } catch (error) {
        this.$message.error(error);
      }
    },
    eliminar(capaBaseId) {
      this.$confirm(
        "¿Está seguro que desea eliminar este elemento?",
        "Advertencia"
      ).then(async () => {
        try {
          await this.$axios.delete(`/usuarios/${capaBaseId}`);
          await this.obtenerTodosUsuarios();
          this.$message.success("El proceso se ha completado correctamente");
        } catch (error) {
          this.$message.error(error);
        }
      });
    },
  },
};
</script>
