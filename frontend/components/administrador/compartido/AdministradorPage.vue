<template>
  <div>
    <header v-if="titulo">
      <el-page-header :content="titulo" @back="() => $router.back()" />
      <el-divider />
    </header>
    <slot />
  </div>
</template>

<script>
export default {
  props: {
    titulo: {
      type: String,
      default: undefined,
    },
  },
};
</script>
