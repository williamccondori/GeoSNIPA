<template>
  <AdministradorPage titulo="Grupo de capas">
    <GrupoCapaTree />
  </AdministradorPage>
</template>

<script>
import AdministradorPage from "@/components/administrador/compartido/AdministradorPage.vue";
import GrupoCapaTree from "@/components/administrador/GrupoCapaTree.vue";
export default {
  components: {
    AdministradorPage,
    GrupoCapaTree,
  },
  layout: "administrador",
};
</script>
