<template>
  <div>
    <el-tree
      node-key="id"
      default-expand-all
      :data="gruposCapas"
      :expand-on-click-node="false"
    >
      <span slot-scope="{ node, data }">
        <span>{{ node.label }}</span>
        <el-button type="text" icon="el-icon-plus" @click="agregar(data.id)" />
        <el-button
          v-if="data.id !== 'root'"
          type="text"
          icon="el-icon-delete"
          @click="eliminar(data.id)"
        />
      </span>
    </el-tree>
    <el-dialog
      :show-close="true"
      :visible="estaAbiertoAgregarGrupoCapaDialog"
      @close="cerrarAgregarGrupoCapaDialog"
    >
      <span slot="title">
        <b>Agregar grupo de capas</b>
      </span>
      <el-form ref="referenciaFormulario" :model="formulario">
        <el-form-item
          prop="nombre"
          label="Nombre:"
          :rules="[
            {
              required: true,
              message: 'Ingrese el nombre del grupo de capas',
            },
          ]"
        >
          <el-input
            v-model="formulario.nombre"
            placeholder="Ingrese el nombre del grupo de capas"
          />
        </el-form-item>
        <el-button
          type="success"
          icon="el-icon-check"
          style="width: 100%"
          @click="guardar()"
        >
          Guardar
        </el-button>
      </el-form>
    </el-dialog>
  </div>
</template>

<script>
import { mapState, mapActions } from "vuex";

const formulario = {
  grupoCapaId: undefined,
  nombre: "",
};

export default {
  data() {
    return {
      formulario: { ...formulario },
      estaAbiertoAgregarGrupoCapaDialog: false,
    };
  },
  async fetch() {
    try {
      await this.obtenerTodosGruposCapas();
    } catch (error) {
      this.$message.error(error);
    }
  },
  computed: {
    ...mapState("administrador", ["gruposCapas"]),
  },
  methods: {
    ...mapActions("administrador", ["obtenerTodosGruposCapas"]),
    agregar(grupoCapaId) {
      this.formulario.grupoCapaId = grupoCapaId;
      this.estaAbiertoAgregarGrupoCapaDialog = true;
    },
    eliminar(grupoCapaId) {
      this.$confirm(
        "¿Está seguro que desea eliminar este grupo de capas?",
        "Advertencia"
      ).then(async () => {
        try {
          await this.$axios.delete(`/grupos-capas/${grupoCapaId}`);
          await this.obtenerTodosGruposCapas();
          this.$message.success("El proceso se ha completado correctamente");
        } catch (error) {
          this.$message.error(error);
        }
      });
    },
    guardar() {
      this.$refs.referenciaFormulario.validate(async (valid) => {
        if (valid) {
          try {
            await this.$axios.post("/grupos-capas", {
              nombre: this.formulario.nombre,
              grupoCapaId:
                this.formulario.grupoCapaId === "root"
                  ? null
                  : this.formulario.grupoCapaId,
              estaHabilitado: true,
            });
            await this.obtenerTodosGruposCapas();
            this.cerrarAgregarGrupoCapaDialog();
            this.$message.success("El proceso se ha completado correctamente");
          } catch (error) {
            this.$message.error(error);
          }
        }
      });
    },
    cerrarAgregarGrupoCapaDialog() {
      this.formulario = { ...formulario };
      this.$refs.referenciaFormulario.resetFields();
      this.estaAbiertoAgregarGrupoCapaDialog = false;
    },
  },
};
</script>
