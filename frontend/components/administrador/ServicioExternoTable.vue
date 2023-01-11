<template>
  <el-table stripe :data="serviciosExternos" border>
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
import { mapState } from "vuex";
export default {
  computed: {
    ...mapState("administrador", ["serviciosExternos"]),
  },
  methods: {
    editar(capaBaseId) {
      console.log(capaBaseId);
    },
    eliminar(capaBaseId) {
      console.log(capaBaseId);
    },
  },
};
</script>
