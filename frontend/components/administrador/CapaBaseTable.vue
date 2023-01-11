<template>
  <el-table stripe :data="capasBase" border>
    <el-table-column prop="nombre" label="Nombre" />
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
      await this.obtenerTodosCapasBase();
    } catch (error) {
      this.$message.error(error);
    }
  },
  computed: {
    ...mapState("administrador", ["capasBase"]),
  },
  methods: {
    ...mapActions("administrador", [
      "obtenerTodosCapasBase",
      "abrirCapaBaseDrawerParaActualizacion",
    ]),
    async editar(capaBaseId) {
      try {
        const { data } = await this.$axios.get(`/capas-base/${capaBaseId}`);
        this.abrirCapaBaseDrawerParaActualizacion(data);
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
          await this.$axios.delete(`/capas-base/${capaBaseId}`);
          await this.obtenerTodosCapasBase();
          this.$message.success("El proceso se ha completado correctamente");
        } catch (error) {
          this.$message.error(error);
        }
      });
    },
  },
};
</script>
